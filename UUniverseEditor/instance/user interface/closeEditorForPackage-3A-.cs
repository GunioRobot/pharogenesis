closeEditorForPackage: package
	| matchingEditors |
	matchingEditors _ packageEditors select: [ :p | p package = package ].
	matchingEditors do: [ :editor |
		editor window delete.
		packageEditors remove: editor ].