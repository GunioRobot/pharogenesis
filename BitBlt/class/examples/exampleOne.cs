exampleOne
	"This tests BitBlt by displaying the result of all sixteen combination rules that BitBlt is capable of using. (Please see the comment in BitBlt for the meaning of the combination rules)."
	| path |
	path _ Path new.
	0 to: 3 do: [:i | 0 to: 3 do: [:j | path add: j * 100 @ (i * 75)]].
	Display fillWhite.
	path _ path translateBy: 60 @ 40.
	1 to: 16 do: [:index | BitBlt
			exampleAt: (path at: index)
			rule: index - 1
			fillColor: Color gray]

	"BitBlt exampleOne"