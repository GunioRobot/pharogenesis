doesNotUnderstand: aMessage 
	"Bring in the object, install, then resend aMessage"
	| aMorph myUrl oldFlag response |
	"Transcript show: thisContext sender selector; cr." "useful for debugging"
	oldFlag _ recursionFlag.
	recursionFlag _ true.
	myUrl _ url.	"can't use inst vars after become"
	"fetch the object"
	aMorph _ self xxxFetch.		"watch out for the become!"
			"Now we ARE a MORPH"
	oldFlag == true ifTrue: [
		response _ (PopUpMenu labels: 'proceed normally\debug' withCRs)
			startUpWithCaption: 'Object being fetched for a second time.
Should not happen, and needs to be fixed later.'.
		response = 2 ifTrue: [self halt]].	"We are already the new object"

	aMorph setProperty: #SqueakPage toValue: 
			(SqueakPageCache pageCache at: myUrl).
	"Can't be a super message, since this is the first message sent to this object"
	^ aMorph perform: aMessage selector withArguments: aMessage arguments
