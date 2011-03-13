fieldList 
	"Refer to the comment in Inspector|fieldList."

	object == nil ifTrue: [^Array with: 'thisContext'].
	^(Array with: 'thisContext' with: 'all temp vars') , object tempNames