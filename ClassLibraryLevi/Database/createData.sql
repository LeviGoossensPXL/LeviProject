USE LaboDB1;
GO

DROP TABLE IF EXISTS Articles;

CREATE TABLE Articles (
  Id INT IDENTITY(1,1)
    CONSTRAINT Articles_PK PRIMARY KEY,
  Title VARCHAR(200)
    CONSTRAINT Articles_Title_NN NOT NULL,
  Content TEXT
    CONSTRAINT Articles_Content_NN NOT NULL,
  PublishedTime DATETIME
    CONSTRAINT Articles_PublishedTime_NN NOT NULL,
  AuthorName VARCHAR(50)
    CONSTRAINT Articles_AuthorName_NN NOT NULL,
  Category VARCHAR(50)
    CONSTRAINT Articles_Category_NN NOT NULL
	CONSTRAINT Articles_Category_CHK CHECK( Category IN ('General', 'Science', 'Politics', 'Technology', 'Sports', 'Entertainment') )
);

INSERT INTO Articles VALUES ('Breakthrough in Quantum Computing Achieved by MIT Researchers', 'In a significant leap forward for the field of quantum computing, researchers at MIT have unveiled a new qubit design that dramatically reduces error rates. This development could pave the way for practical quantum systems capable of outperforming classical computers on complex problems. The team used a novel material that stabilizes qubit states longer than previously possible, allowing for deeper computation cycles without data corruption.

Experts are hailing this breakthrough as a step closer to realizing scalable, reliable quantum computing. The findings were published in Nature Physics, with experiments conducted over a span of 18 months. Government agencies and private tech firms are already expressing interest in collaborating to explore the commercial potential of this innovation.', '2025-05-21 09:00:00', 'Dr. Susan Park', 'Science'),
('Global Streaming Giant Acquires Indie Film Studio to Expand Content Library', 'In a surprising move, global streaming leader CineWave has announced the acquisition of independent film studio Moonlight Pictures. The deal, valued at $600 million, aims to diversify CineWave’s content portfolio with award-winning indie films and festival favorites. Moonlight Pictures, known for its critically acclaimed storytelling and diverse casts, will retain its creative autonomy under the agreement.

Industry analysts view this acquisition as part of a growing trend where major platforms seek to balance mass-appeal programming with niche, high-quality productions. CineWave CEO Jordan Reaves emphasized the importance of storytelling diversity and hinted at upcoming exclusive releases under the Moonlight banner.', '2025-05-20 15:30:00', 'Lisa Martinez', 'Entertainment');