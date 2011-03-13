explanation

	(key isMemberOf: Association) ifFalse: [
		^'Literal ', key storeString
	].
	key key isNil ifTrue: [
		^'Literal ', ('###',key value soleInstance name) 
	] ifFalse: [
		^'Literal ', ('##', key key) 
	].	