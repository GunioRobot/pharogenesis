at: frameNumber put: newData
	"Add newData to the keyframe list at the given frameNumber"
	| kf |
	kfList ifNil:[kfList := OrderedCollection new].
	kfList isEmpty ifFalse:["Check if we can extend the last interval"
		kf := kfList last.
		kf stop < frameNumber 
			ifFalse:[^self replaceData: newData at: frameNumber].
		kf data = newData "Extend interval to include frameNumber"
			ifTrue:[	kf stop: frameNumber.
					^newData].
		"Extend last interval to just before frameNumer"
		kf stop: frameNumber - 1].
	kfList add: (FlashKeyframe from: frameNumber to: frameNumber data: newData).
	^newData