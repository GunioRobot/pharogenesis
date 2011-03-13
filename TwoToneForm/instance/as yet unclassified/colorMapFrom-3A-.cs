colorMapFrom: sourceForm
	| map |
	map _ Bitmap new: (1 bitShift: (sourceForm depth min: 9)).
	1 to: map size do: [:i | map at: i put: 16rFFFFFFFF].
	map at: (backgroundColor mapIndexForDepth: sourceForm depth) put: 0.
	^ map