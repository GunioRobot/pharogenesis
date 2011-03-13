wantsFrameAdornments
	"Answer whether the receiver wishes to have red borders, etc.,  
	used to show editing state"
	"A 'long-term temporary workaround': a nonmodular,  
	unsavory, but expedient way to get the desired effect, sorry.  
	Clean up someday."
	^ self
		valueOfProperty: #wantsFrameAdornments
		ifAbsent: [([Preferences showTextEditingState] on: Error do: [true]) "handle missing preference"
					ifTrue: [(#(annotation searchString infoViewContents ) includes: getTextSelector) not]
					ifFalse: [false]]