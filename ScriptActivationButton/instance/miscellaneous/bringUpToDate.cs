bringUpToDate
	"The object's name, or the script name, or both, may have changed.  Make sure I continue to look and act right"

	uniclassScript ifNotNil:
		[arguments _ Array with: uniclassScript selector].
	self establishLabelWording