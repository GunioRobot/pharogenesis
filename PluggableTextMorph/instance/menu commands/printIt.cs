printIt
	| result oldEditor |

	textMorph editor selectFrom: selectionInterval first to: selectionInterval last;
						model: model.  "For, eg, evaluateSelection"
	textMorph handleEdit: [result := (oldEditor := textMorph editor) evaluateSelection].
	((result isKindOf: FakeClassPool) or: [result == #failedDoit]) ifTrue: [^self flash].
	selectionInterval := oldEditor selectionInterval.
	textMorph installEditorToReplace: oldEditor.
	textMorph handleEdit: [oldEditor afterSelectionInsertAndSelect: result printString].
	selectionInterval := oldEditor selectionInterval.
	
	textMorph editor selectFrom: selectionInterval first to: selectionInterval last.
	self scrollSelectionIntoView.

