receiver: rcvr selector: selNode arguments: args precedence: p 
	"Decompile."

	self receiver: rcvr
		arguments: args
		precedence: p.
	special _ MacroSelectors indexOf: selNode key.
	selector _ selNode.
	"self pvtCheckForPvtSelector: encoder"	"We could test code being decompiled, but the compiler should've checked already. And where to send the complaint?"