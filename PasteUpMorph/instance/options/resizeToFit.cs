resizeToFit
	"Answer whether the receiver exhibits the #resizeToFit property.  Formerly of greater use, this is an obscure backwater not meriting much attention.  For most practical purposes, this is just always false.  The feature doesn't quite work right even where used, e.g. in the Tabs sorter"
	^ resizeToFit ifNil: [resizeToFit _ false]