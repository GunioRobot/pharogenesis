saveToDiskMenuAction
	[ self saveAddressBookAsObjectToFile: 'defaultAddressBook.ser'.
	  self alert: 'Save successful!']
		on: Error
		do: [:err | 
			self alert: 'Error while saving:' , err messageText.
			err defaultAction]