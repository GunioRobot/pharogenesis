handlesFilename: filename
	^#('.cs' '.st' '.st.gz' '.cs.gz') anySatisfy: [ :ending | filename endsWith: ending ]