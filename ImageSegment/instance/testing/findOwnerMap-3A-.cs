findOwnerMap: morphs
	| st |
	"Construct a string that has a printout of the owner chain for every morph in the list.  Need it as a string so not hold onto them."

st _ ''.
morphs do: [:mm |
	(st includesSubString: mm printString) ifFalse: [
		st _ st, '
', mm allOwners printString]].
Smalltalk at: #Owners put: st.
