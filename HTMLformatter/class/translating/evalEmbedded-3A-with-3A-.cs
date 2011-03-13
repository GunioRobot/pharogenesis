evalEmbedded: stringOrStream with: request
	| formatter |
	formatter _ self forEvaluatingEmbedded: stringOrStream.
	^formatter format: request