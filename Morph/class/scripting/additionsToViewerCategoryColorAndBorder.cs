additionsToViewerCategoryColorAndBorder
	"Answer viewer additions for the 'color & border' category"

	^#(
		#'color & border' 
		(
			(slot color 'The color of the object' Color readWrite Player getColor  Player  setColor:)
			(slot opacity '0 means completely transparent, 1 means completely opaque' Number readWrite Player getAlpha Player setAlpha:)
			(slot borderStyle 'The style of the object''s border' BorderStyle readWrite Player getBorderStyle player setBorderStyle:)
			(slot borderColor 'The color of the object''s border' Color readWrite Player getBorderColor Player  setBorderColor:)
			(slot borderWidth 'The width of the object''s border' Number readWrite Player getBorderWidth Player setBorderWidth:)
			(slot roundedCorners 'Whether corners should be rounded' Boolean readWrite Player getRoundedCorners Player setRoundedCorners:)

			(slot gradientFill 'Whether a gradient fill should be used' Boolean readWrite Player getUseGradientFill Player setUseGradientFill:)
			(slot secondColor 'The second color used when gradientFill is in effect' Color readWrite Player getSecondColor Player setSecondColor:)

			(slot radialFill 'Whether the gradient fill, if used, should be radial' Boolean readWrite Player getRadialGradientFill Player setRadialGradientFill:)

			(slot dropShadow 'Whether a drop shadow is shown' Boolean readWrite Player getDropShadow Player setDropShadow:)
			(slot shadowColor 'The color of the drop shadow' Color readWrite Player getShadowColor Player setShadowColor:)
		)
	)

