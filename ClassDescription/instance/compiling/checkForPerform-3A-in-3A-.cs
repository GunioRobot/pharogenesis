checkForPerform: selector in: aController
	"If this newly accepted method contains a perform:, remind the user to put in fake code with the selectors the perform would use.  So senders of those selectors will find this code.  tck 1991
	1/22/96 sw: MacPal -> Utilities
	1/24/96 sw: temporarily, at least, bypassed this guy"
 
	| meth hasPerform |
	self flag: #noteToDan.
	"Ted put this into our image back in 1991, in an effort to force uses who insist on using #perform to put some fake source into their code so that all the selectors likely to be invoked by the perform will be retrieved when one queries senders.  While agreeing this a promising approach, in practice I found it quite a nuisance and also the found the implementation somewhat flawed, so for the moment (more for my personal convenience than as any kind of formal statement) I've commented it out...  2/5/96 sw"

	"My approach to this would be to disallow all uses of perform:, and replace them with
	obj perform: selector from: #(list of selectors).
This provides in-code documenstation, leverage for senders and inplementersOf.  It gives type inference the clue it needs as well, not to mention the possibility of run-time checks on perform: 4/22/96 di"

	true ifTrue: [^ ''].

	selector == nil ifTrue: [^ ''].
	meth _ self compiledMethodAt: selector.
	hasPerform _ false.
	#(perform: perform:with: perform:with:with: perform:with:with:with: perform:withArguments:) do: [:each |
		(meth pointsTo: "faster than hasLiteral:" each) ifTrue: [
			hasPerform _ true]].
	hasPerform ifFalse: [^ self].		"normal case, no perform: here"
	(meth pointsTo: #doNotListPerformSelectors) ifTrue: [^ ''].
	Sensor leftShiftDown ifTrue: [^ ''].  
		"When need to accept a method that has many selectors performed
		and needs to be fast so don't want to include doNotListPerformSelectors."

	self inform: 
'This method contains a perform:.
Please list all selectors that will 
be performed in the Selectors 
Performed section of this method.'.

	(meth pointsTo: #listPerformSelectorsHere) ifFalse: [
		"insert section in the method"
		^ '.

	false ifTrue: ["Selectors Performed"
		"Please list all selectors that could be args to the 
		perform: in this method.  Do this so senders will find
		this method as one of the places the selector is sent from."
		"Use a temp with the class name as the reciever, like this:
		aBrowser accept."
		self listPerformSelectorsHere.		"tells the parser its here"
		].']