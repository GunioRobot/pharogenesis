cachedForm
	"Answer the value of cachedForm"
	
	|form i effectiveAlpha|
	cachedForm ifNil: [
		i := self image.
		self layout == #scaled
			ifTrue: [self extent = i extent
						ifFalse: [i := i magnify: i boundingBox by: (self extent / i extent) smoothing: 2]]
			ifFalse: [self scale ~= 1
					ifTrue: [i := i magnify: i boundingBox by: self scale smoothing: 2]].
		effectiveAlpha := self enabled
			ifTrue: [self alpha]
			ifFalse: [self alpha / 2].
		effectiveAlpha = 1.0
		ifTrue: [self cachedForm: i]
		ifFalse: [form := Form extent: i extent depth: 32.
				form fillColor: (Color white alpha: 0.003922).
				(form getCanvas asAlphaBlendingCanvas: effectiveAlpha)
					drawImage: i
				at: 0@0.
				self cachedForm: form]].
	^cachedForm