contentType: header
	"extract the content type from the header.  Content-type: text/plain<cr><lf>,  User may look in headerTokens afterwards."

	| this |
	headerTokens ifNil: [ headerTokens _ header findTokens: ParamDelimiters keep: (String with: CR) ].
	1 to: headerTokens size do: [:ii | 
		this _ headerTokens at: ii.
		(this first asLowercase = $c and: [#('content-type:' 'content type') includes: this asLowercase]) ifTrue: [
			^ (headerTokens at: ii+1)]].
	^ nil	"not found"