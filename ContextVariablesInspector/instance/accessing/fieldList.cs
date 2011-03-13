fieldList 
	"Refer to the comment in Inspector|fieldList."

	| fields |
	object == nil ifTrue: [^Array with: 'thisContext'].
	fields _ (Array with: 'thisContext' with: 'all temp vars') , object tempNames.
	object myEnv ifNotNil: [
		fields _ fields, object capturedTempNames].
	^ fields