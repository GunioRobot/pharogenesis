vmPath
	"Answer the path for the directory containing the Smalltalk virtual machine. Return the empty string if this primitive is not implemented."
	"Smalltalk vmPath"

	^ self deprecated: 'Use SmalltalkImage current vmPath'
		block: [SmalltalkImage current vmPath]