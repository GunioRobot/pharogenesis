useKedamaFloatArray

	| newArray |
	arrays withIndexDo: [:array :index |
		(array isMemberOf: FloatArray) ifTrue: [
			newArray _ KedamaFloatArray new: array size.
			newArray replaceFrom: 1 to: array size with: array startingAt: 1.
			arrays at: index put: newArray.
		].
	].
