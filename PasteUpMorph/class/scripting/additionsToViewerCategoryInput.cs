additionsToViewerCategoryInput
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(input (
			(slot lastKeystroke 'The last unhandled keystroke' String readWrite Player getLastKeystroke Player setLastKeystroke:)
	))