decompilerFailures
	"here is the list of failures: DNU resulting in trying to decompile the following methods"

	^ #((BalloonEngineSimulation circleCosTable "-0.3826834323650903 => -0.38268343236509 or -0.3826834323650902")
		 (BalloonEngineSimulation circleSinTable "-0.3826834323650903 => -0.38268343236509 or -0.3826834323650902")
		 (GeniePlugin primSameClassAbsoluteStrokeDistanceMyPoints:otherPoints:myVectors:otherVectors:mySquaredLengths:otherSquaredLengths:myAngles:otherAngles:maxSizeAndReferenceFlag:rowBase:rowInsertRemove:rowInsertRemoveCount: "Cannot compile -- stack including temps is too deep")
		(QPickable2D pick:) "foo ifTrue: [^bar] ifFalse: [^baz]. ^huh?"
		(QUsersPane userEntryCompare:to:) "foo ifTrue: [^bar] ifFalse: [^baz]. ^huh?"
		(TShaderProgram vertexStrings) "foo ifTrue: []. => foo. => ."
		(TShaderProgram fragmentStrings) "foo ifTrue: []. => foo. => ."
		(TWindow zoomWindow:) "foo ifTrue: [^bar] ifFalse: [^baz]. ^huh?"

		"(PNMReadWriter nextImage) (Collection #ifEmpty:ifNotEmpty:) (Collection #ifEmpty:) (Collection #ifNotEmpty:ifEmpty:) (Text #alignmentAt:ifAbsent:) (ObjectWithDocumentation propertyAt:ifAbsent:)")