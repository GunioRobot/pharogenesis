addColumnBreak

	| ed old new break |

	ed _ self editor.
	old _ ed selection.
	break _ TextComposer characterForColumnBreak asString.
	break _ Text string: break attributes: {}.
	new _ old ,break.
	ed replaceSelectionWith: new.
	self releaseParagraphReally.
	self layoutChanged.

