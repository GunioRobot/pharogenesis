permuteData
	| i end a b |
	i _ 1.
	end _ permTable size.
	[i <= end] whileTrue:
		[a _ permTable at: i.
		b _ permTable at: i+1.
		realData swap: a with: b.
		imagData swap: a with: b.
		i _ i + 2]