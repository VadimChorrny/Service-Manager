select * from SubscriptionsSearches where SearchPhone <> null
select * from Services as s join SubscriptionsSearches as ss on s.Id = ss.ServiceId where s.Name = 'New test A'
delete from Services;