shiftedYellowButtonMessages
	"Answer the set of messages that go with the shifted menu.  Inconvenient to have it here in this separate method; when/if we consolidate via a class variable, as for unshifted, the problem will go away.  1/17/96 sw
	 3/7/96 sw: added methodSourceContainingIt
	 3/13/96 sw: merged ParagraphEditor and StringHolderController versions into ParagraphEditor, and deleted the StringHolderController versions
	 5/27/96 sw: added offerFontMenu
	 8/20/96 sw: makeover"

	^ #(offerFontMenu changeStyle explain format fileItIn recognizeCharacters spawn browseIt sendersOfIt implementorsOfIt referencesToIt  methodNamesContainingIt methodStringsContainingit methodSourceContainingIt  presentSpecialMenu unshiftedYellowButtonActivity)

"set font... (k)
set style... (K)
explain
format
file it in
recognizer (r)
spawn (o)
browse it (b)
senders of it (n)
implementors of it (m)
references to it (N)
selectors containing it (W)
method strings with it
method source with it
special menu...
more..."