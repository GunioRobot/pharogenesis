nu: order
	"Initialize variables and tables for transforming 2^nu points"
	|  j perms k |
	nu _ order.
	n _ 2 bitShift: nu-1.

	"Initialize permutation table (bit-reversed indices)"
	j_0.
	perms _ WriteStream on: (Array new: n).
	0 to: n-2 do:
		[:i |
		i < j ifTrue: [perms nextPut: i+1; nextPut: j+1].
		k _ n // 2.
		[k <= j] whileTrue: [j _ j-k.  k _ k//2].
		j _ j + k].
	permTable _ perms contents.

	"Initialize sin table 0..pi/2 in n/4 steps."
	sinTable _ (0 to: n/4) collect: [:i | (i asFloat / (n//4) * Float pi / 2.0) sin]