initFromArray: anArray
	"Fill the bitmap from anArray.  If the array is shorter,
	then cycle around in its contents until the bitmap is filled."
	| ax as |
	ax _ 0.
	as _ anArray size.
	1 to: bits size do:
		[:index |
		(ax _ ax + 1) > as ifTrue: [ax _ 1].
		bits at: index put: (anArray at: ax)]