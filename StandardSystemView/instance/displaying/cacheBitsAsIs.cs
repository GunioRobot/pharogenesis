cacheBitsAsIs
	CacheBits ifFalse: [^ self uncacheBits].
	windowBits _ (self cacheBitsAsTwoTone and: [Display depth > 1])
		ifTrue: [ColorForm
					twoToneFromDisplay: self windowBox
					using: windowBits
					backgroundColor: self backgroundColor]
		ifFalse: [Form fromDisplay: self windowBox using: windowBits].
	bitsValid _ true.
