addNewContact
	|cabc|
	"Ask the CABContact to do the dirty works:"
	cabc _ CABContact newFromUserInput.
	cabc ifNil:[ self alert: 'Cancelled by user'. ^self. ].
	contactList at: (cabc email) put: cabc.
	self changed: #contactList.