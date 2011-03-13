wrapDirection
	"Layout specific. This property describes the direction along which a list-like layout should be wrapped. Possible values are:
		#leftToRight
		#rightToLeft
		#topToBottom
		#bottomToTop
		#none
	indicating in which direction wrapping should occur. This direction must be orthogonal to the list direction, that is if listDirection is #leftToRight or #rightToLeft then wrapDirection must be #topToBottom or #bottomToTop and vice versa."
	| props |
	props _ self layoutProperties.
	^props ifNil:[#none] ifNotNil:[props wrapDirection].