import React, { useState } from 'react'
import * as Dialog from "@radix-ui/react-dialog";

export default () => {
    const [formData, setFormData] = useState({ name: "", description: "" })

    const submitRequest = () => {
        console.log('siuccess')
    }

  return (
    <Dialog.Root className="fixed inset-0 z-10 overflow-y-auto">
        <div className='flex flex-row-reverse'>
            <Dialog.Trigger className="py-1 px-3 text-lg rounded-md drop-shadow-md bg-gunmetal font-medium text-white right-0">
                Create request
            </Dialog.Trigger>
        </div>
      <Dialog.Portal>
        <Dialog.Overlay className="data-[state=open]:animate-overlayShow fixed inset-0 w-full h-full bg-black opacity-40" />
        <Dialog.Content className="fixed top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] w-full max-w-lg mx-auto px-4">
          <div className="bg-white rounded-md shadow-lg px-4 py-6">
            <div className="flex items-center justify-end">
              <Dialog.Close className="p-2 text-gray-400 rounded-md hover:bg-gray-100">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  className="w-5 h-5 mx-auto"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                >
                  <path
                    fillRule="evenodd"
                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                    clipRule="evenodd"
                  />
                </svg>
              </Dialog.Close>
            </div>
            <div className="max-w-sm mx-auto space-y-3 text-center ">
              <Dialog.Title className="text-lg font-medium text-gray-800 ">
                Create channel creation request
              </Dialog.Title>

              <Dialog.Description className=" text-sm text-gray-600">
                <p>
                  This request will be review by the administrators of chathub, uppon successful approval your request will be proccessed
                </p>
              </Dialog.Description>
              <fieldset className="Fieldset relative">
                <input
                  onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                  className="w-full pl-3 pr-3 py-2 text-gray-500 bg-transparent outline-none border focus:border-gunmetal shadow-sm rounded-lg"
                  placeholder="Enter channel name"
                />
                <input
                onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                  className="w-full pl-3 pr-3 py-2 my-2 text-gray-500 bg-transparent outline-none border focus:border-gunmetal shadow-sm rounded-lg"
                  placeholder="Enter channel short description"
                />
              </fieldset>
              <Dialog.Close asChild>
                <button onClick={submitRequest} className=" w-full mt-3 py-3 px-4 font-medium text-sm text-center text-white bg-paynesgray hover:bg-gunmetal active:bg-coral rounded-lg ring-offset-2 ring-coral focus:ring-2">
                  Create request
                </button>
              </Dialog.Close>
            </div>
          </div>
        </Dialog.Content>
      </Dialog.Portal>
    </Dialog.Root>
  );
};