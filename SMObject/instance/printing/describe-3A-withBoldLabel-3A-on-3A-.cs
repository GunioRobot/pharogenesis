describe: string withBoldLabel: label on: stream
	"Helper method for doing styled text."

	stream withAttribute: (TextEmphasis bold) do: [ stream nextPutAll: label ].
	stream nextPutAll: string; cr