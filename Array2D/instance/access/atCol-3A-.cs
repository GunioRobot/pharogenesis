atCol: i
    "Fetch a whole column.  6/20/96 tk"

	| ans |
	ans _ contents class new: self height.
    1 to: self height do: [:ind |
		ans at: ind put: (self at: i at: ind)].
	^ ans