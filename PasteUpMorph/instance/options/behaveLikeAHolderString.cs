behaveLikeAHolderString
	"Answer a string to be displayed in a menu to characterize 
	whether the receiver is currently behaving like a holder"
	^ (self behavingLikeAHolder
		ifTrue: ['<yes>']
		ifFalse: ['<no>'])
		, 'behave like a holder' translated