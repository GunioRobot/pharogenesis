shapeChoices

	^ ShapeChoices ifNil: [
		ShapeChoices _ {
			{ {  0 @ 0 .  1 @ 0 .  0 @ 1 .  1 @ 1  } }.	"square - one is sufficient here"
			self flipShapes: {  0 @  0 . -1 @  0 .  1 @  0 .  0 @ -1  }.	"T"
			{ 
				{  0 @ 0 . -1 @ 0 .  1 @ 0 .  2 @ 0  }.
				{  0 @ 0 .  0 @-1 .  0 @ 1 .  0 @ 2  } 	"long - two are sufficient here"
			}.
			self flipShapes: { 0 @ 0 .  0 @ -1 .  0 @  1 .  1 @  1  }.	"L"
			self flipShapes: { 0 @ 0 .  0 @ -1 .  0 @  1 . -1 @  1  }.	"inverted L"
			self flipShapes: { 0 @ 0 . -1 @  0 .  0 @ -1 .  1 @ -1  }.	"S"
			self flipShapes: {  0 @ 0 .  1 @ 0 .  0 @ -1 . -1 @ -1  } "Z"
		}.
	]
