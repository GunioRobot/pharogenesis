isNullMarker: aMarker
	"Answer true if aMarker is nil or is one of the symbols in #(none #nil unused missing) -- to service a variety of historical conventions"

	^ aMarker isNil or: [#(none #nil unused missing) includes: aMarker]

"
MethodInterface isNullMarker: nil
MethodInterface isNullMarker: #nil
MethodInterface isNullMarker: #none
MethodInterface isNullMarker: #znak
"