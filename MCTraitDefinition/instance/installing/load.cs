load
	 self createClass ifNotNilDo: [:trait |
		self hasComment ifTrue: [trait classComment: comment stamp: commentStamp]]