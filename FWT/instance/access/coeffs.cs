coeffs
	"Return all coefficients needed to reconstruct the original samples"
	| header csize strm |
	header _ Array with: nSamples with: nLevels with: alpha with: beta.
	csize _ header size.
	1 to: nLevels do: [:i | csize _ csize + (transform at: i*2) size].
	csize _ csize + (transform at: nLevels*2-1) size.
	coeffs _ Array new: csize.
	strm _ WriteStream on: coeffs.
	strm nextPutAll: header.
	1 to: nLevels do: [:i | strm nextPutAll: (transform at: i*2)].
	strm nextPutAll: (transform at: nLevels*2-1).
	^ coeffs