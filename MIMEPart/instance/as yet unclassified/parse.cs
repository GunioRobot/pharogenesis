parse
	| parseStream |
	fields _ Dictionary new.
	parseStream _ ReadStream on: self text.
	self fieldsFrom: parseStream do: [:key :value | fields at: key put: (MIMEHeaderValue fromString: value)].
	content _ parseStream upToEnd