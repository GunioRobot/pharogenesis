flipVertically
	"Flip the texture vertically"

	| temp h w row |

	h _ self height.
	w _ self width.

	0 to: ((h // 2) - 1) do: [:i |
		row _ h - i - 1.
		1 to: w do: [:j |
				temp _ bits at: ((i * w) + j).
				bits at:  ((i * w) + j) put: (bits at: ((row * w) + j)).
				bits at: ((row * w) + j) put: temp.
					].
				].
