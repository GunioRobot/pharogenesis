vmParameterAt: parameterIndex
	"See comment for SmalltalkImage>vmParameterAt:"

	^ self deprecated: 'Use SmalltalkImage current vmParameterAt:'
		block: [SmalltalkImage current vmParameterAt: parameterIndex]
	