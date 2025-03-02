import { useEffect, useState } from 'react'
import { Curriculum } from './Models/Curriculum'
import { CurriculumService } from './Services/CurriculumServices'

function App() {

  const [curriculums, setCurriculums] = useState<Curriculum[]>([])
  const [curriculum, setCurriculum] = useState<Partial<Curriculum>>({})
  const [isEdit, setIsEdit] = useState<boolean>(false);

  useEffect(() => {
    getData();
  }, [])

  const getData = async () => {
    const data = await CurriculumService.Get();
    setCurriculums(data);
  };

  const handleCreate = async () => {
    await CurriculumService.Post(curriculum);
    reset();
  }

  const handleUpdate = async () => {
    if (curriculum.id) {
      await CurriculumService.Edit(curriculum as Curriculum);
      reset();
    }
  };

  const handleDelete = async (id: number) => {
    await CurriculumService.Delete(id);
    getData();
  }

  const handleEditForm = (curriculum: Curriculum) => {
    setCurriculum(curriculum);
    setIsEdit(true);
  }

  const reset = () => {
    setCurriculum({});
    setIsEdit(false);
    getData();
  }

  return (
    <>
      <div>
        <table className="table m-3">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Name</th>
              <th scope="col">Email</th>
              <th scope="col">Formation</th>
              <th scope="col">Phone</th>
              <th scope="col">Actions</th>

            </tr>
          </thead>
          <tbody className="table-group-divider">
            {curriculums.length > 0 ? (
              curriculums.map(((current, index) =>
                <tr key={index}>
                  <td>{current.id}</td>
                  <td>{current.name}</td>
                  <td>{current.email}</td>
                  <td>{current.formation}</td>
                  <td>{current.phoneNumber}</td>
                  <td>
                    <button className="btn btn-sm btn-primary m-1" onClick={() => handleEditForm(current)}>Edit</button>
                    <button className="btn btn-sm btn-danger" onClick={() => handleDelete(current.id)}>Delete</button>
                  </td>
                </tr>
              ))

            ) : (
              <tr>
                <td colSpan={6}><strong>No curriculums available...</strong></td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
        <button
          className="btn btn-primary m-3"
          onClick={isEdit ? handleUpdate : handleCreate}
        >
          {isEdit ? "Update" : "Create"}
        </button>
      <div className='m-3'>
        <input
          className="form-control p-1 m-1"
          value={curriculum.name || ''}
          onChange={(e) => setCurriculum({ ...curriculum, name: e.target.value })}
          type="text"
          placeholder="Name"
        />
        <input
          className="form-control p-1 m-1"
          value={curriculum.email || ''}
          onChange={(e) => setCurriculum({ ...curriculum, email: e.target.value })}
          type="text"
          placeholder="Email"
        />
        <input
          className="form-control p-1 m-1"
          value={curriculum.formation || ''}
          onChange={(e) => setCurriculum({ ...curriculum, formation: e.target.value })}
          type="text"
          placeholder="Formation"
        />
        <input
          className="form-control p-1 m-1"
          value={curriculum.phoneNumber || ''}
          onChange={(e) => setCurriculum({ ...curriculum, phoneNumber: Number(e.target.value) })}
          type="text"
          placeholder="Phone Number"
        />
      </div>
    </>
  )
}

export default App
