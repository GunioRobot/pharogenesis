keyStroke: evt
	"This is hugely inefficient, but it seems to work, and it's unlikely it will ever need
	to be any more efficient -- it's only intended to edit single-line strings."

	| char priorEditor oldSel newSel |
	(((char _ evt keyCharacter) = Character enter) or: [(char = Character cr)
			or: [char = $s and: [evt commandKeyPressed]]])
				ifTrue: [owner acceptContents; doneWithEdits.
						evt hand newKeyboardFocus: nil.
						^ self delete].
	
	(char = $l and: [evt commandKeyPressed]) ifTrue:   "cancel"
		[owner cancelEdits.
		evt hand newKeyboardFocus: nil.
		^ self delete].

	oldSel _ self editor selectionInterval.
	super keyStroke: evt.
	owner interimContents: self contents asString.
	newSel _ self editor selectionInterval.

	priorEditor _ self editor.  "Save editor state"
	self releaseParagraph.  "Release paragraph so it will grow with selection."
	self paragraph.      "Re-instantiate to set new bounds"
	self installEditorToReplace: priorEditor.  "restore editor state"

	oldSel = newSel ifTrue:
		["There is a bug that causes characters to be misplaced when the second
		character typed is wider than the first.  This fixes it (ugh)."
		self editor selectFrom: newSel first + 1 to: newSel last + 1].

