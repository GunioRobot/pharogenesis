defaultWindow 
	"Refer to the comment in View|defaultWindow."

	^(Rectangle origin: 0 @ 0 extent: model extent)
		expandBy: borderWidth