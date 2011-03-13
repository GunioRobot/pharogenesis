askIfAddStyle: priorMethod req: requestor
	"Ask the user if we have a complex style (i.e. bold) for the first time"

	| tell answ old |
	self runs coalesce.
	self unembellished ifTrue: [^ self asString].

	priorMethod ifNotNil: [old _ priorMethod getSourceFromFile].
	(old == nil or: [old unembellished]) ifTrue: [
		tell _ 'This method contains style (i.e. bold) for the first time.
Do you really want to save the style info?'.
		answ _ (PopUpMenu labels: 'Save method with style
Save method simply') startUpWithCaption: tell. 
		answ = 2 ifTrue: [ 
			"Dan, here is where to tell it to display self asString" "requestor model changed." 
			^ self asString]].
	"^ self		keep my style"