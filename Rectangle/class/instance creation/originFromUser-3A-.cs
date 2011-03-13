originFromUser: extentPoint 
	"Answer an instance of me that is determined by having the user 
	designate the top left corner. The width and height are determined by 
	extentPoint. The gridding for user selection is 1@1."

	^self originFromUser: extentPoint grid: 1 @ 1