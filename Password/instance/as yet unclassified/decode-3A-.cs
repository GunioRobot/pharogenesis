decode: string
	"Xor with secret number -- just so file won't have raw password in it"
	| kk rand |
	rand _ Random new seed: 234237.
	kk _ (ByteArray new: string size) collect: [:bb | (rand next * 255) asInteger].
	1 to: kk size do: [:ii |
		kk at: ii put: ((kk at: ii) bitXor: (string at: ii) asciiValue)].
	^ kk asString