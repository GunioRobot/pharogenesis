canDockWith: otherPin
	"Later include data type compatibility and circularity as well"
	(pinSpec isInputOnly and: [otherPin pinSpec isInputOnly]) ifTrue: [^ false].
	(pinSpec isOutputOnly and: [otherPin pinSpec isOutputOnly]) ifTrue: [^ false].
	^ true