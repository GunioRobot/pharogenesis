askIfAddStyle: priorMethod req: requestor
	"Ask the user if we have a complex style (i.e. bold) for the first time.
	NOTE: requestor should revert to plain text if this is chosen"
	| tell answ old |
	self runs coalesce.
	self unembellished ifTrue: [^ self asString].

	priorMethod ifNotNil: [old _ priorMethod getSourceFromFile].
	(old == nil or: [old unembellished]) ifTrue: [
		tell _ 'This method contains style (bold, links, etc).
Do you really want to save the style info?'.
		answ _ (PopUpMenu labels: 'Save method with style
Save as plain text') startUpWithCaption: tell. 
		answ = 2 ifTrue: [^ self asString  "...and requestor should revert here"]].
	^ self		"keep my style"