computeInsetDisplayBox
	"This overrides the same method in View.  (It avoids using displayTransform: because it can return inaccurate results, causing a MorphWorldView's inset display box to creep inward when resized.)"

	^superView insetDisplayBox insetBy: borderWidth