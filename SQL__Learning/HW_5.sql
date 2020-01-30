--TASK 1
CREATE PROC auggust_event
 AS SELECT EventName
 FROM tblEvent
 WHERE Month(EventDate) = 08

 EXECUTE auggust_event
 
--TASK 2
CREATE PROC GetCoutriesWith1ID_one
 AS SELECT CountryName
 FROM tblCountry
 WHERE ContinentID = 1
 ORDER BY CountryName

 EXECUTE GetCoutriesWith1ID_one
 
 --TASK 3
 CREATE PROC EpisodesWithSmith
AS SELECT tblEpisode.Title
FROM tblEpisode, tblDoctor
WHERE tblDoctor.DoctorName LIKE 'Matt Smith'
AND tblDoctor.DoctorId=tblEpisode.DoctorId

EXECUTE EpisodesWithSmith

--TASK 4
CREATE PROC EpisodesWithAuthor_Final (@author NVARCHAR(30))
AS SELECT tblEpisode.Title
FROM tblCompanion INNER JOIN tblEpisodeCompanion ON tblCompanion.CompanionId=tblEpisodeCompanion.EpisodeCompanionId
INNER JOIN tblEpisode ON tblEpisodeCompanion.EpisodeId = tblEpisode.EpisodeId
WHERE tblCompanion.WhoPlayed LIKE @author

EXECUTE EpisodesWithAuthor_Final 'Alex%'

--TASK 5 
CREATE PROC TOP3Companion
AS SELECT TOP(3) tblEpisodeCompanion.CompanionId, COUNT(tblEpisodeCompanion.EpisodeId) AS countID--, tblCompanion.CompanionName
FROM tblEpisodeCompanion 
INNER JOIN tblCompanion ON tblEpisodeCompanion.CompanionId=tblCompanion.CompanionId
GROUP BY tblEpisodeCompanion.CompanionId
ORDER BY COUNT(tblEpisodeCompanion.EpisodeId) DESC


--Trigger 1
CREATE TRIGGER   CountryNameChange
ON dbo.tblCountry
AFTER UPDATE
AS 
PRINT 'Trigger: Changing Country name'
SELECT 'Country Name updated - ' + CountryName
FROM dbo.tblCountry