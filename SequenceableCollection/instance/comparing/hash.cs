hash
"Answer an integer hash value for the receiver such that,
  -- the hash value of an unchanged object is constant over time, and
  -- two equal objects have equal hash values."
    | size |
	(size _ self size) = 0 ifTrue: [^ 17171].
	^ size + (self at: 1) hash + (self at: size) hash