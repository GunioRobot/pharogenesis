type
	"Answer the type of the receiver, initializing it to Number if it is nil"

	type isEmptyOrNil ifTrue: [^ type _ #Number].
	type first isUppercase ifFalse: [^ type _ type capitalized].
		"because of lingering, annoying issue of projects created in a plug-in image"
	^ type